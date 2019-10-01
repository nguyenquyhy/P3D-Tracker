﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace FlightTracker.DTOs
{
    [System.Diagnostics.DebuggerDisplay("{Title}")]
    public class InputFlightData
    {
        public InputFlightData() { }

        public InputFlightData(InputFlightData data)
        {
            var properties = this.GetType().GetProperties();
            foreach (var property in properties)
            {
                property.SetValue(this, property.GetValue(data));
            }
        }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTimeOffset StartDateTime { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? EndDateTime { get; set; }

        public DateTimeOffset? TakeOffDateTime { get; set; }
        public DateTimeOffset? LandingDateTime { get; set; }

        public string Airline { get; set; }
        public string FlightNumber { get; set; }
        public string AirportFrom { get; set; }
        public string AirportTo { get; set; }

        public AircraftData Aircraft { get; set; }

        public FlightStatus StatusTakeOff { get; set; }
        public FlightStatus StatusLanding { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FlightState State { get; set; } = FlightState.Started;

        public FlightPlan FlightPlan { get; set; }
    }

    public class FlightData : InputFlightData
    {
        public string Id { get; set; }

        public DateTimeOffset AddedDateTime { get; set; }

        public int? FuelUsed { get; set; }
        public int? DistanceFlown { get; set; }
    }

    public enum FlightState
    {
        Started,
        Enroute,
        Arrived,
        Crashed,
        Lost
    }
}
