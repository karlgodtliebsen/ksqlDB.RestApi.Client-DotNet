﻿using Kafka.DotNet.ksqlDB.KSql.Query;

namespace ksqlDB.Api.Client.Tests.Models.Movies
{
  public class Lead_Actor : Record
  {
    public string Title { get; set; }
    public string Actor_Name { get; set; }
  }
}