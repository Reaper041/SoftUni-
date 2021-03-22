using System;
using System.Collections.Generic;
using System.Text;
using PersonInfo;

namespace PersonInfo
{
    public class Robot : IRobot, IIdentifiable 
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }

        public string Id { get; set; }
    }
}
