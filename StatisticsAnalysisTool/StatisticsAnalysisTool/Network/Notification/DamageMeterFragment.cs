﻿using StatisticsAnalysisTool.Annotations;
using StatisticsAnalysisTool.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StatisticsAnalysisTool.Network.Notification
{
    public class DamageMeterFragment : INotifyPropertyChanged
    {
        private string _name;
        private Guid _causerGuid;
        private string _damage;
        private double _damageInPercent;
        private Item _causerMainHand;
        private string _categoryId;
        private string _dps;

        public string Name {
            get => _name;
            set {
                _name = value;
                OnPropertyChanged();
            }
        }

        public Guid CauserGuid {
            get => _causerGuid;
            set {
                _causerGuid = value;
                OnPropertyChanged();
            }
        }

        public string Damage {
            get => _damage;
            set {
                _damage = value;
                OnPropertyChanged();
            }
        }

        public string Dps {
            get => _dps;
            set {
                _dps = value;
                OnPropertyChanged();
            }
        }

        public double DamageInPercent {
            get => _damageInPercent;
            set {
                _damageInPercent = value;
                OnPropertyChanged();
            }
        }
        
        public Item CauserMainHand {
            get => _causerMainHand;
            set {
                _causerMainHand = value;
                CategoryId = _causerMainHand?.FullItemInformation?.CategoryId;
                OnPropertyChanged();
            }
        }
        
        public string CategoryId {
            get => _categoryId;
            set {
                _categoryId = value;
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}