using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo.RocketAPI.Console
{
    public sealed class SingletonSettings
    {
        private static volatile SingletonSettings instance;
        private static object syncSettings = new Object();

        private SingletonSettings()
        {
            
        }

        public static SingletonSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncSettings)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonSettings();

                            instance.accountInfo = new AccountInfo();
                        }
                    }
                }

                return instance;
            }
        }

        private AccountInfo accountInfo;

        public AccountInfo AccountInfo
        {
            get
            {
                return accountInfo;
            }
            set
            {
                accountInfo = value;
            }
        }
    }

    public class AccountInfo : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string propertyName;
        public string ProfileName
        {
            get
            {
                return propertyName;
            }
            set
            {
                propertyName = value;
                NotifyPropertyChanged("ProfileName");
            }
        }

    }


}
