using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MarchePOS.Core.Mvvm
{
    public class DomainObject : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private ErrorsContainer<ValidationResult> errorsContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainObject"/> class.
        /// </summary>
        protected DomainObject()
        {
        }

        /// <summary>
        /// sets the storage to the value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns>True if the value was changed, false if the existing value matched the desired value.</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            ValidateProperty(propertyName, value);

            if (object.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners. This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected void OnPropertyChanged(string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Event raised when a property value changes.
        /// </summary>
        /// <seealso cref="INotifyPropertyChanged"/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event raised when the validation status changes.
        /// </summary>
        /// <seealso cref="INotifyDataErrorInfo"/>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// Gets the error status.
        /// </summary>
        /// <seealso cref="INotifyDataErrorInfo"/>
        public bool HasErrors
        {
            get { return this.ErrorsContainer.HasErrors; }
        }

        /// <summary>
        /// Gets the container for errors in the properties of the domain object.
        /// </summary>
        protected ErrorsContainer<ValidationResult> ErrorsContainer
        {
            get
            {
                if (this.errorsContainer == null)
                {
                    this.errorsContainer =
                        new ErrorsContainer<ValidationResult>(pn => this.RaiseErrorsChanged(pn));
                }

                return this.errorsContainer;
            }
        }

        /// <summary>
        /// Returns the errors for <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property for which the errors are requested.</param>
        /// <returns>An enumerable with the errors.</returns>
        /// <seealso cref="INotifyDataErrorInfo"/>
        public IEnumerable GetErrors(string propertyName)
        {
            return this.errorsContainer.GetErrors(propertyName);
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the changed property.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">The argument for the event.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Validates <paramref name="value"/> as the value for the property named <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The value for the property.</param>
        protected void ValidateProperty(string propertyName, object value)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            this.ValidateProperty(new ValidationContext(this, null, null) { MemberName = propertyName }, value);
        }

        /// <summary>
        /// Validates <paramref name="value"/> as the value for the property specified by 
        /// <paramref name="validationContext"/> using data annotations validation attributes.
        /// </summary>
        /// <param name="validationContext">The context for the validation.</param>
        /// <param name="value">The value for the property.</param>
        protected virtual void ValidateProperty(ValidationContext validationContext, object value)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException("validationContext");
            }

            List<ValidationResult> validationResults = new List<ValidationResult>();
            Validator.TryValidateProperty(value, validationContext, validationResults);

            this.ErrorsContainer.SetErrors(validationContext.MemberName, validationResults);
        }

        /// <summary>
        /// Raises the <see cref="ErrorsChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property which changed its error status.</param>
        protected void RaiseErrorsChanged(string propertyName)
        {
            this.OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the <see cref="ErrorsChanged"/> event.
        /// </summary>
        /// <param name="e">The argument for the event.</param>
        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            this.ErrorsChanged?.Invoke(this, e);
        }
    }
}
