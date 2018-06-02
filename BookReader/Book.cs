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

        public List<Page> Pages { get; } = new List<Page>();

        public Book(string text)
        {
            this._text = text;
            ProcessText();
            ProcessPages(_text);
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

        public void Update()
        {
            ProcessText();
            ProcessPages(_text);
        }

        private void ProcessText()
        {
            bool newLine = false;

            for (int i = 0; i < GetText.Length; i++)
            {
                if (i % _textWidth == 0)
                {
                    _text =GetText.Insert(i, "\t\n\t");
                    newLine = !newLine;
                }
            }
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
