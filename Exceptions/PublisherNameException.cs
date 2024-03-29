﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Exceptions
{
    public class PublisherNameException : Exception
    {
        public string PublisherName { get; set; }

        //constructor
        public PublisherNameException()
        {

        }

        public PublisherNameException(string message) : base(message)
        {

        }
        public PublisherNameException(string message, Exception inner) : base(message, inner)
        {

        }

        public PublisherNameException(string message, string publishername) : this(message)
        {
            PublisherName = publishername;
        }
    }


}
