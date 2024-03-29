﻿using ExibitMeProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ExibitMeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitorRegPage : ContentPage
    {
        public VisitorRegPage()
        {
            InitializeComponent();
            this.BindingContext = new VisitorRegPageViewModel();
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            VisitorRegPageViewModel viewModel = BindingContext as VisitorRegPageViewModel;
            if (viewModel.shareData)
            {
                Visitor visitor = new Visitor();
                visitor.FullName = FullNameEntry.Text;
                visitor.EmailAddress = EmailAddressEntry.Text;
                visitor.Password = PasswordEntry.Text;

                SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation);
                sQLiteconnection.CreateTable<Visitor>();
                int insertedRows = sQLiteconnection.Insert(visitor);
                sQLiteconnection.Close();

                if (insertedRows > 0)
                {
                    _ = DisplayAlert("Gelukt", "Registratie gelukt", "Ok");
                    Xamarin.Essentials.Vibration.Vibrate(500);
                    Navigation.PopAsync();
                }
                else
                {
                    _ = DisplayAlert("Niet Gelukt", "Registratie mislukt", "Ok");
                    Xamarin.Essentials.Vibration.Vibrate(500);
                }

                //using SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
                //sQLiteConnection.CreateTable<Visitor>();
                //sQLiteConnection.Insert(new Visitor { FullName = FullNameEntry.Text, EmailAddress = EmailAddressEntry.Text, Phone = PhoneEntry.Text });
                //Application.Current.Properties["FullName"] = FullNameEntry.Text;
                //Application.Current.Properties["EmailAddress"] = EmailAddressEntry.Text;
                //Application.Current.Properties["Password"] = PasswordEntry.Text;
                //Application.Current.Properties["Phone"] = PhoneEntry.Text;
                //DisplayAlert("", "Registration Succesful!", "OK");
                //Xamarin.Essentials.Vibration.Vibrate(2000);
                //Navigation.PopAsync();
            }
            else
            {
                Visitor visitor = new Visitor();
                visitor.FullName = FullNameEntry.Text;
                visitor.EmailAddress = EmailAddressEntry.Text;
                visitor.Password = PasswordEntry.Text;
                visitor.Street = StreetEntry.Text;
                visitor.PostalCode = PostalCodeEntry.Text;
                visitor.City = CityEntry.Text;
                visitor.State = StateEntry.Text;
                visitor.Country = CountryEntry.Text;
                visitor.Phone = PhoneEntry.Text;
                visitor.Occupation = OccupationEntry.Text;

                SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation);
                sQLiteconnection.CreateTable<Visitor>();
                int insertedRows = sQLiteconnection.Insert(visitor);
                sQLiteconnection.Close();

                if (insertedRows > 0)
                {
                    _ = DisplayAlert("Gelukt", "Registratie gelukt", "Ok");
                    Xamarin.Essentials.Vibration.Vibrate(500);
                    Navigation.PopAsync();
                }
                else
                {
                    _ = DisplayAlert("Niet Gelukt", "Registratie mislukt", "Ok");
                    Xamarin.Essentials.Vibration.Vibrate(500);
                }
                //using SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
                //sQLiteConnection.CreateTable<Visitor>();
                //sQLiteConnection.Insert(new Visitor { FullName = FullNameEntry.Text, EmailAddress = EmailAddressEntry.Text, Street = StreetEntry.Text, PostalCode = PostalCodeEntry.Text, City = CityEntry.Text, State = StateEntry.Text, Country = CountryEntry.Text, Phone = PhoneEntry.Text, Occupation = OccupationEntry.Text });
                //Application.Current.Properties["FullName"] = FullNameEntry.Text;
                //Application.Current.Properties["EmailAddress"] = EmailAddressEntry.Text;
                //Application.Current.Properties["Password"] = PasswordEntry.Text;
                //Application.Current.Properties["Street"] = StreetEntry.Text;
                //Application.Current.Properties["PostalCode"] = PostalCodeEntry.Text;
                //Application.Current.Properties["City"] = CityEntry.Text;
                //Application.Current.Properties["State"] = StateEntry.Text;
                //Application.Current.Properties["Country"] = CountryEntry.Text;
                //Application.Current.Properties["Phone"] = PhoneEntry.Text;
                //Application.Current.Properties["Occupation"] = OccupationEntry.Text;
                //DisplayAlert("", "Registration Succesful!", "OK");
                //Xamarin.Essentials.Vibration.Vibrate(2000);
                //Navigation.PopAsync();
            }
        }

        private void ShareDataOption_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ShareDataOption.IsChecked)
            {
                PostalCode.IsVisible = false;
                City.IsVisible = false;
                State.IsVisible = false;
                Country.IsVisible = false;
                Street.IsVisible = false;
                Occupation.IsVisible = false;
                Phone.IsVisible = false;
            }
            else
            {
                FullName.IsVisible = true;
                EmailAddress.IsVisible = true;
                Phone.IsVisible = true;
                PostalCode.IsVisible = true;
                City.IsVisible = true;
                State.IsVisible = true;
                Country.IsVisible = true;
                Street.IsVisible = true;
                Occupation.IsVisible = true;
            }
        }


        public class VisitorRegPageViewModel : INotifyPropertyChanged
        {
            private bool _shareData;
            public bool shareData
            {
                get { return _shareData; }
                set
                {
                    _shareData = value;
                    OnPropertyChanged();
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class BooleanConverter : IValueConverter, IMarkupExtension
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return !((bool)value);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value;
            }

            public object ProvideValue(IServiceProvider serviceProvider)
            {
                return this;
            }
        }
    }
}



