﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


namespace Microsoft.IIS.Administration.WebServer.Monitoring
{
    using Microsoft.IIS.Administration.Monitoring;
    using Microsoft.Web.Administration;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    class AppPoolMonitor : IAppPoolMonitor
    {
        CounterProvider _counterProvider;
        private Dictionary<int, string> _processCounterInstances = new Dictionary<int, string>();

        public AppPoolMonitor(CounterProvider provider)
        {
            _counterProvider = provider;
        }

        public async Task<IEnumerable<IAppPoolSnapshot>> GetSnapshots(IEnumerable<ApplicationPool> pools)
        {
            var snapshots = new List<IAppPoolSnapshot>();

            foreach (var pool in pools) {
                snapshots.Add(await GetSnapShot(pool));
            }

            return snapshots;
        }

        private async Task<AppPoolSnapshot> GetSnapShot(ApplicationPool pool)
        {
            var snapshot = new AppPoolSnapshot();

            snapshot.Name = pool.Name;
            snapshot.ProcessCount = pool.GetWorkerProcesses().Count();

            foreach (IPerfCounter counter in await Query(pool)) {

                if (counter.CategoryName.Equals(WorkerProcessCounterNames.Category)) {
                    switch (counter.Name) {
                        case WorkerProcessCounterNames.ActiveRequests:
                            snapshot.ActiveRequests += counter.Value;
                            break;
                        case WorkerProcessCounterNames.Percent500:
                            snapshot.Percent500 += counter.Value;
                            break;
                        case WorkerProcessCounterNames.RequestsSec:
                            snapshot.RequestsSec += counter.Value;
                            break;
                        case WorkerProcessCounterNames.TotalRequests:
                            snapshot.TotalRequests += counter.Value;
                            break;
                        case WorkerProcessCounterNames.CurrentFileCacheMemoryUsage:
                            snapshot.FileCacheMemoryUsage += counter.Value;
                            break;
                        case WorkerProcessCounterNames.CurrentFilesCached:
                            snapshot.CurrentFilesCached += counter.Value;
                            break;
                        case WorkerProcessCounterNames.CurrentUrisCached:
                            snapshot.CurrentUrisCached += counter.Value;
                            break;
                        case WorkerProcessCounterNames.FileCacheHits:
                            snapshot.FileCacheHits += counter.Value;
                            break;
                        case WorkerProcessCounterNames.FileCacheMisses:
                            snapshot.FileCacheMisses += counter.Value;
                            break;
                        case WorkerProcessCounterNames.OutputCacheCurrentItems:
                            snapshot.OutputCacheCurrentItems += counter.Value;
                            break;
                        case WorkerProcessCounterNames.OutputCacheCurrentMemoryUsage:
                            snapshot.OutputCacheCurrentMemoryUsage += counter.Value;
                            break;
                        case WorkerProcessCounterNames.OutputCacheTotalHits:
                            snapshot.OutputCacheTotalHits += counter.Value;
                            break;
                        case WorkerProcessCounterNames.OutputCacheTotalMisses:
                            snapshot.OutputCacheTotalMisses += counter.Value;
                            break;
                        case WorkerProcessCounterNames.TotalFilesCached:
                            snapshot.TotalFilesCached += counter.Value;
                            break;
                        case WorkerProcessCounterNames.TotalUrisCached:
                            snapshot.TotalUrisCached += counter.Value;
                            break;
                        case WorkerProcessCounterNames.UriCacheHits:
                            snapshot.UriCacheHits += counter.Value;
                            break;
                        case WorkerProcessCounterNames.UriCacheMisses:
                            snapshot.UriCacheMisses += counter.Value;
                            break;
                        default:
                            break;
                    }
                }

                if (counter.CategoryName.Equals(ProcessCounterNames.Category)) {
                    switch (counter.Name) {
                        case ProcessCounterNames.PercentCpu:
                            snapshot.PercentCpuTime += counter.Value;
                            break;
                        case ProcessCounterNames.HandleCount:
                            snapshot.HandleCount += counter.Value;
                            break;
                        case ProcessCounterNames.PrivateBytes:
                            snapshot.PrivateBytes += counter.Value;
                            break;
                        case ProcessCounterNames.ThreadCount:
                            snapshot.ThreadCount += counter.Value;
                            break;
                        case ProcessCounterNames.PrivateWorkingSet:
                            snapshot.PrivateWorkingSet += counter.Value;
                            break;
                        case ProcessCounterNames.WorkingSet:
                            snapshot.WorkingSet += counter.Value;
                            break;
                        case ProcessCounterNames.IOReadSec:
                            snapshot.IOReadSec += counter.Value;
                            break;
                        case ProcessCounterNames.IOWriteSec:
                            snapshot.IOWriteSec += counter.Value;
                            break;
                        case ProcessCounterNames.PageFaultsSec:
                            snapshot.PageFaultsSec += counter.Value;
                            break;
                        default:
                            break;
                    }
                }
            }

            return snapshot;
        }

        private async Task<IEnumerable<IPerfCounter>> Query(ApplicationPool pool)
        {
            for (int i = 0; i < 5; i++) {
                try {
                    return await GetCounters(pool);
                }
                catch (CounterNotFoundException) {
                    await Task.Delay(20);
                }
            }

            return await GetCounters(pool);
        }

        private async Task<IEnumerable<IPerfCounter>> GetCounters(ApplicationPool pool)
        {
            var poolCounters = new List<IPerfCounter>();
            var wps = pool.GetWorkerProcesses();

            foreach (string instance in await GetProcessCounterInstances(wps.Select(wp => wp.ProcessId))) {
                poolCounters.AddRange(await _counterProvider.GetCounters(ProcessCounterNames.Category, instance));
            }

            foreach (WorkerProcess wp in wps) {
                poolCounters.AddRange(await _counterProvider.GetCounters(WorkerProcessCounterNames.Category, WorkerProcessCounterNames.GetInstanceName(wp.ProcessId, pool.Name)));
            }

            return poolCounters;
        }

        private async Task<IEnumerable<string>> GetProcessCounterInstances(IEnumerable<int> ids)
        {
            foreach (int id in ids) {
                if (!_processCounterInstances.ContainsKey(id)) {

                    _processCounterInstances.Clear();

                    foreach (var instance in await ProcessUtil.GetProcessCounterInstances(ids)) {
                        _processCounterInstances[id] = instance;
                    }

                    break;
                }
            }

            return ids.Select(processId => _processCounterInstances[processId]);
        }
    }

    public static class PExt
    {
        public static IEnumerable<WorkerProcess> GetWorkerProcesses(this ApplicationPool pool)
        {
            return ManagementUnit.ServerManager.WorkerProcesses.Where(wp => wp.AppPoolName == pool.Name);
        }
    }
}