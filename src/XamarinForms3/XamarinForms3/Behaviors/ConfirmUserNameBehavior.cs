using System;
using Xamarin.Forms;

namespace XamarinForms3.Behaviors
{
    public class ConfirmUserNameBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty CompareEntryProperty = BindableProperty.Create(nameof(CompareEntry), typeof(Entry), typeof(ConfirmUserNameBehavior), null);

        public Entry CompareEntry
        {
            get => (Entry)GetValue(CompareEntryProperty);
            set => SetValue(CompareEntryProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(CompareEntry.Text))
            {
                return;
            }

            if (CompareEntry.Text == e.NewTextValue)
            {
                Xamarin.Forms.VisualStateManager.GoToState((Entry)sender, "correct");
                Xamarin.Forms.VisualStateManager.GoToState((Entry)CompareEntry, "correct");
            }
            else
            {
                Xamarin.Forms.VisualStateManager.GoToState((Entry)sender, "fail");
                Xamarin.Forms.VisualStateManager.GoToState((Entry)CompareEntry, "fail");
            }
        }
    }
}
