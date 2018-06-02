using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BookReader
{
    class Book
    {
        private const int DefaultTextWidth = 100;
        private const int DefaultTextHeight = 15;

        private String _text;
        private int _textWidth = DefaultTextWidth;
        private int _textHeight = DefaultTextHeight;

        public List<Page> Pages { get; set; } = new List<Page>();

        public Book(string text)
        {
            this._text = text;

            ProcessPages(ProcessText(_text));
        }

        public string GetText => _text;

        public int TextWidth
        {
            get => _textWidth;
            set => _textWidth = value;
        }

        public int TextHeight
        {
            get => _textHeight;
            set => _textHeight = value;
        }

        public Page GetPage(int index)
        {
            return Pages[index];
        }

        public void Update(int size)
        {
            Pages = new List<Page>();
            _textHeight = (DefaultTextHeight / 5) * size;
            _textWidth = (DefaultTextWidth / 5) * size;
            ProcessPages(ProcessText(_text));
        }

        private String ProcessText(String text)
        {
            bool newLine = false;
            String ret = text;

            for (int i = 0; i < GetText.Length; i++)
            {
                if (i % _textWidth == 0)
                {
                    ret = ret.Insert(i, "\t\n\t");
                    newLine = !newLine;
                }
            }

            return ret;
        }

        private void ProcessPages(String text)
        {
            int Length () => text.Length;
            int pageCharsCount = TextHeight * _textWidth;

            while (Length() > pageCharsCount)
            {
                Pages.Add(new Page(text.Substring(0, pageCharsCount)));
                text = text.Substring(pageCharsCount, Length() - pageCharsCount);
            }

            Pages.Add(new Page(text));
        }
    }
}
