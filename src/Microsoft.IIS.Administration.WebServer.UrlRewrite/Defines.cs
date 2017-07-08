// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


namespace Microsoft.IIS.Administration.WebServer.UrlRewrite
{
    using Core;
    using System;

    public class Defines
    {
        private const string ENDPOINT = "url-rewrite";
        private const string SERVER_VARIABLES_ENDPOINT = "server-variables";
        private const string REWRITE_MAPS_SECTION_ENDPOINT = "rewrite-maps";
        private const string REWRITE_MAPS_ENDPOINT = "maps";
        private const string INBOUND_RULES_SECTION_ENDPOINT = "inbound-rules";
        private const string INBOUND_RULES_ENDPOINT = "entries";
        private const string OUTBOUND_RULES_SECTION_ENDPOINT = "outbound-rules";
        private const string OUTBOUND_RULES_ENDPOINT = "entries";
        private const string PRECONDITIONS_ENDPOINT = "preconditions";
        private const string CUSTOM_TAGS_ENDPOINT = "custom_tags";

        // Feature resource
        public const string UrlRewriteName = "Microsoft.WebServer.UrlRewrite";
        public static ResDef Resource = new ResDef("url_rewrite", new Guid("BBB27846-37A0-4651-94DC-04A01B53C6B5"), ENDPOINT);
        public static readonly string PATH = $"{WebServer.Defines.PATH}/{ENDPOINT}";
        public const string IDENTIFIER = "url_rewrite.id";

        // Server Variables
        public const string ServerVariablesName = "Microsoft.WebServer.UrlRewrite.AllowedVariables";
        public static ResDef ServerVariablesResource = new ResDef("allowed_server_variables", new Guid("C8093ECD-B304-44B8-B1C5-61395FE26578"), SERVER_VARIABLES_ENDPOINT);
        public static readonly string SERVER_VARIABLES_PATH = $"{PATH}/{SERVER_VARIABLES_ENDPOINT}";
        public const string SERVER_VARIABLE_IDENTIFIER = "allowed_server_variable.id";

        // Rewrite Maps Section
        public const string RewriteMapsSectionName = "Microsoft.WebServer.UrlRewrite.RewriteMaps";
        public static ResDef RewriteMapsSectionResource = new ResDef("rewrite_maps", new Guid("F5F65122-BF1A-4A5B-9734-FCF35F2131B5"), REWRITE_MAPS_SECTION_ENDPOINT);
        public static readonly string REWRITE_MAPS_SECTION_PATH = $"{PATH}/{REWRITE_MAPS_SECTION_ENDPOINT}";
        public const string REWRITE_MAPS_SECTION_IDENTIFIER = "rewrite_maps.id";

        // Rewrite Maps Section
        public const string RewriteMapsName = "Microsoft.WebServer.UrlRewrite.RewriteMaps.Maps";
        public const string RewriteMapName = "Microsoft.WebServer.UrlRewrite.RewriteMaps.Maps";
        public static ResDef RewriteMapsResource = new ResDef("maps", new Guid("EA768756-34B7-4664-AE88-E5E888860139"), REWRITE_MAPS_ENDPOINT);
        public static readonly string REWRITE_MAPS_PATH = $"{REWRITE_MAPS_SECTION_PATH}/{REWRITE_MAPS_ENDPOINT}";
        public const string REWRITE_MAPS_IDENTIFIER = "map.id";

        // Inbound Rules Section
        public const string InboundRulesSectionName = "Microsoft.WebServer.UrlRewrite.InboundRules";
        public static ResDef InboundRulesSectionResource = new ResDef("inbound_rules", new Guid("DA8765E5-42BA-4282-9D06-016191EAE4A5"), INBOUND_RULES_SECTION_ENDPOINT);
        public static readonly string INBOUND_RULES_SECTION_PATH = $"{PATH}/{INBOUND_RULES_SECTION_ENDPOINT}";
        public const string INBOUND_RULES_SECTION_IDENTIFIER = "inbound_rules.id";

        // Inbound Rules
        public const string InboundRulesName = "Microsoft.WebServer.UrlRewrite.InboundRules.Entries";
        public const string InboundRuleName = "Microsoft.WebServer.UrlRewrite.InboundRules.Entry";
        public static ResDef InboundRulesResource = new ResDef("entries", new Guid("F78AD889-464B-407D-926F-F52B7CAF7595"), INBOUND_RULES_ENDPOINT);
        public static readonly string INBOUND_RULES_PATH = $"{INBOUND_RULES_SECTION_PATH}/{INBOUND_RULES_ENDPOINT}";
        public const string INBOUND_RULE_IDENTIFIER = "inbound_rule.id";

        // Outbound Rules Section
        public const string OutboundRulesSectionName = "Microsoft.WebServer.UrlRewrite.OutboundRoules";
        public static ResDef OutboundRulesSectionResource = new ResDef("outbound_rules", new Guid("3b6491d8-81db-493b-8597-190273682f73"), OUTBOUND_RULES_SECTION_ENDPOINT);
        public static readonly string OUTBOUND_RULES_SECTION_PATH = $"{PATH}/{OUTBOUND_RULES_SECTION_ENDPOINT}";
        public const string OUTBOUND_RULES_SECTION_IDENTIFIER = "outbound_rules.id";

        // Outbound Rules
        public const string OutboundRulesName = "Microsoft.WebServer.UrlRewrite.OutboundRules.Entries";
        public const string OutboundRuleName = "Microsoft.WebServer.UrlRewrite.OutboundRules.Entry";
        public static ResDef OutboundRulesResource = new ResDef("entries", new Guid("64d4131c-572a-48db-95e7-95fd74843ccd"), OUTBOUND_RULES_ENDPOINT);
        public static readonly string OUTBOUND_RULES_PATH = $"{OUTBOUND_RULES_SECTION_PATH}/{OUTBOUND_RULES_ENDPOINT}";
        public const string OUTBOUND_RULE_IDENTIFIER = "outbound_rule.id";

        // PreConditions
        public const string PreConditionsName = "Microsoft.WebServer.UrlRewrite.OutboundRules.PreConditions";
        public const string PreConditionName = "Microsoft.WebServer.UrlRewrite.OutboundRules.PreCondition";
        public static ResDef PreConditionsResource = new ResDef("preconditions", new Guid("06b92165-a952-452e-a45e-98e623f8cfd6"), PRECONDITIONS_ENDPOINT);
        public static readonly string PRECONDITIONS_PATH = $"{OUTBOUND_RULES_SECTION_PATH}/{PRECONDITIONS_ENDPOINT}";
        public const string PRECONDITION_IDENTIFIER = "precondition.id";

        // CustomTags
        public const string CustomTagsName = "Microsoft.WebServer.UrlRewrite.OutboundRules.CustomTags";
        public const string CustomTagName = "Microsoft.WebServer.UrlRewrite.OutboundRules.CustomTag";
        public static ResDef CustomTagsResource = new ResDef("custom_tags", new Guid("5088fd60-2d25-4cf9-af08-7fd5c01ba8c2"), CUSTOM_TAGS_ENDPOINT);
        public static readonly string CUSTOM_TAGS_PATH = $"{OUTBOUND_RULES_SECTION_PATH}/{CUSTOM_TAGS_ENDPOINT}";
        public const string CUSTOM_TAG_IDENTIFIER = "custom_tag.id";

    }
}
