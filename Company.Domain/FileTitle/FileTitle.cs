
using _0_Framework.Domain;
using System;
using System.Collections.Generic;

namespace Company.Domain.FileTitle
{
    public class FileTitle : EntityBase
    {
        public FileTitle(string title, string type)
        {
            Title = title;
            Type = type;
        }

        public string Title { get; set; }
        public string Type { get; set; }


        public void Edit(string title, string type)
        {
            Title = title;
            Type = type;
        }
    }
}