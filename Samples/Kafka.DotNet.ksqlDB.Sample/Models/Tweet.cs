﻿using System.Text.Json.Serialization;
using Kafka.DotNet.ksqlDB.KSql.Query;
using Kafka.DotNet.ksqlDB.KSql.RestApi.Statements.Annotations;

namespace ksqlDB.Api.Client.Samples.Models
{
  public class Tweet : Record
  {
    public int Id { get; set; }

    [JsonPropertyName("MESSAGE")]
    public string Message { get; set; }

    
    public double Amount { get; set; }
    
    [Decimal(3,2)]
    public decimal AccountBalance { get; set; }
  }
}