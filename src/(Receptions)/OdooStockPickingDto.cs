﻿using Newtonsoft.Json;
using PortaCapena.OdooJsonRpcClient.Attributes;
using PortaCapena.OdooJsonRpcClient.Converters;
using PortaCapena.OdooJsonRpcClient.Models;

namespace Odoo.Warehouse.SDK
{
    [OdooTableName("stock.picking")]
    [JsonConverter(typeof(OdooModelConverter))]
    public class OdooStockPickingDto : IOdooModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
