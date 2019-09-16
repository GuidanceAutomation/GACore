using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GACore
{
	/// <summary>
	/// Generic mailbox structure for storing updates for a unique object.
	/// </summary>
	/// <typeparam name="T">Key (struct)</typeparam>
	/// <typeparam name="U">Mail (class)</typeparam>
	public abstract class GenericMailbox<T, U> : INotifyPropertyChanged where T : struct where U : class
	{
		private readonly T key;

		private U mail;

		public GenericMailbox(T key, U mail)
		{
			if (mail == null) throw new ArgumentNullException("mail");

			this.key = key;
			this.mail = mail;
		}

		public U Mail
		{
			get { return mail; }

			private set
			{
				if (mail != value)
				{
					mail = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public override int GetHashCode() => Key.GetHashCode();

		public override bool Equals(object obj)
		{
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				GenericMailbox<T, U> other = (GenericMailbox<T, U>)obj;

				return Key.Equals(other.Key);
			}
		}

		public string ToMailBoxString() => string.Format("Mailbox: {0}", Key);

		public override string ToString() => ToMailBoxString();

		public void Update(U newMail)
		{
			if (newMail == null) throw new ArgumentNullException("newMail");

			Mail = newMail;
		}

		public T Key => key;

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}