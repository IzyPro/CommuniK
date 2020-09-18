using Humanizer;
using MvvmHelpers;
using System;
using System.Collections.ObjectModel;

namespace CommuniK.Models
{
    public class Message : BaseViewModel
    {
        private string _text;
        private bool _isIncoming;
        private string _attachementUrl;
        private DateTime _messageDateTime;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
        public DateTime MessageDateTime
        {
            get { return _messageDateTime; }
            set
            {
                _messageDateTime = value;
                OnPropertyChanged();
            }
        }
        public bool IsIncoming
        {
            get { return _isIncoming; }
            set
            {
                _isIncoming = value;
                OnPropertyChanged();
            }
        }
        public string AttachementUrl
        {
            get { return _attachementUrl; }
            set
            {
                _attachementUrl = value;
                OnPropertyChanged();
            }
        }

        public string MessageTimeDisplay => MessageDateTime.Humanize();
        public bool HasAttachement => !string.IsNullOrEmpty(AttachementUrl);

    }
    //public class Message : ObservableObject
    //{
    //    string text;

    //    public string Text
    //    {
    //        get { return text; }
    //        set { SetProperty(ref text, value); }
    //    }

    //    DateTime messageDateTime;

    //    public DateTime MessageDateTime
    //    {
    //        get { return messageDateTime; }
    //        set { SetProperty(ref messageDateTime, value); }
    //    }

    //    public string MessageTimeDisplay => MessageDateTime.Humanize();

    //    bool isIncoming;

    //    public bool IsIncoming
    //    {
    //        get { return isIncoming; }
    //        set { SetProperty(ref isIncoming, value); }
    //    }

    //    public bool HasAttachement => !string.IsNullOrEmpty(attachementUrl);

    //    string attachementUrl;

    //    public string AttachementUrl
    //    {
    //        get { return attachementUrl; }
    //        set { SetProperty(ref attachementUrl, value); }
    //    }

    //}
}