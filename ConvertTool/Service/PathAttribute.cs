using System;
using System.Net;
using Common.Enums;

namespace Service
{
    [AttributeUsage(AttributeTargets.Method)]
    sealed class PathAttribute:Attribute
    {
        public string Path { set; get; }
        public Constants.RequestMethod Method { set; get; }

        public PathAttribute(string path, Constants.RequestMethod method= Constants.RequestMethod.GET)
        {
            Path = path;
            Method = method;
        }
    }
}