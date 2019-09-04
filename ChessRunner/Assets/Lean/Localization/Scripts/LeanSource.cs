using UnityEngine;
using System.Collections.Generic;

namespace Lean.Localization
{
	/// <summary>This is the interface used for all translation sources. When a translation source is built, it will populate the LeanLocalization class with its translation data.</summary>
	public abstract class LeanSource : MonoBehaviour
	{
		public static LinkedList<LeanSource> Instances = new LinkedList<LeanSource>();

		[System.NonSerialized]
		private LinkedListNode<LeanSource> node;

		public abstract void Compile(string primaryLanguage, string secondaryLanguage);

		protected virtual void OnEnable()
		{
			node = Instances.AddLast(this);

			LeanLocalization.DelayUpdateTranslations();
		}

		protected virtual void OnDisable()
		{
			Instances.Remove(node);

			LeanLocalization.DelayUpdateTranslations();
		}
	}
}