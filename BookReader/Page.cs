using System;
using System.Collections.Generic;
using System.Text;

namespace BookReader
{
    class Page
    {
        private readonly string _text;

        public Page(string text)
        {
            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}