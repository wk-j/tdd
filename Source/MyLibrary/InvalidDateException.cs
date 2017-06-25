using System;

namespace MyLibrary {
    public class InvalidDateException : Exception {
        public InvalidDateException(string ex) : base(ex) {}

    }
}