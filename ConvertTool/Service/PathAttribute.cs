using System;
using System.Net;

namespace Service
{
    [AttributeUsage(AttributeTargets.Method)]
    sealed class PathAttribute:Attribute
    {
        public string Path { set; get; }

        public PathAttribute(string path)
        {
            Path = path;
        }
    }
}