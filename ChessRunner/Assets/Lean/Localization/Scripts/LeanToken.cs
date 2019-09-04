using UnityEngine;
using System.Collections.Generic;
using Lean.Common;
#if UNITY_EDITOR
using UnityEditor;

namespace Lean.Localization
{
	[CustomEditor(typeof(LeanToken))]
	public class LeanToken_Inspector : LeanInspector<LeanToken>
	{
		protected override void DrawInspector()
		{
			Draw("value");
		}
	}
}
#endif

namespace Lean.Localization
{
	/// <summary>The class stores a token name (e.g. "AGE"), allowing it to be replaced with the token value (e.g. "20").
	/// To use the token in your text, simply include the token name surrounded by braces (e.g. "I am {AGE} years old!")</summary>
	[ExecuteInEditMode]
	[HelpURL(LeanLocalization.HelpUrlPrefix + "LeanToken")]
	[AddComponentMenu(LeanLocalization.ComponentPathPrefix + "Token")]
	public class LeanToken : LeanSource
	{
		[SerializeField]
		private string value;

		[System.NonSerialized]
		private HashSet<ILocalizationHandler> handlers;

		[System.NonSerialized]
		private static HashSet<ILocalizationHandler> tempHandlers = new HashSet<ILocalizationHandler>();

		public string Value
		{
			set
			{
				if (this.value != value)
				{
					this.value = value;

					if (handlers != null)
					{
						tempHandlers.Clear();

						tempHandlers.UnionWith(handlers);

						foreach (var handler in tempHandlers)
						{
							handler.UpdateLocalization();
						}
					}
				}
			}

			get
			{
				return value;
			}
		}

		public void SetValue(float value)
		{
			Value = value.ToString();
		}

		public void SetValue(string value)
		{
			Value = value;
		}

		public void SetValue(int value)
		{
			Value = value.ToString();
		}

		public void Register(ILocalizationHandler handler)
		{
			if (handler != null)
			{
				if (handlers == null)
				{
					handlers = new HashSet<ILocalizationHandler>();
				}

				handlers.Add(handler);
			}
		}

		public void Unregister(ILocalizationHandler handler)
		{
			if (handlers != null)
			{
				handlers.Remove(handler);
			}
		}

		public void UnregisterAll()
		{
			if (handlers != null)
			{
				foreach (var handler in handlers)
				{
					handler.Unregister(this);
				}

				handlers.Clear();
			}
		}

		public override void Compile(string primaryLanguage, string secondaryLanguage)
		{
			if (string.IsNullOrEmpty(name) == false)
			{
				LeanLocalization.CurrentTokens.Add(name, this);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();

			UnregisterAll();
		}
	}
}