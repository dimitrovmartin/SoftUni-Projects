﻿using System;

namespace PersonInfo
{
    public class Robot : IRobot, IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; }

        public string Id { get; }
    }
}
