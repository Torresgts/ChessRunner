using UnityEngine;
using System.Collections.Generic;
using Lean.Common;
#if UNITY_EDITOR
using UnityEditor;

namespace Lean.Localization.Examples
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(LeanLanguageCSV), true)]
	public class LeanLanguageCSV_Inspector : LeanInspector<LeanLanguageCSV>
	{
		protected override void DrawInspector()
		{
			Draw("Source", "The text asset that contains all the translations.");
			Draw("Language", "The language of the translations in the source file.");
			Draw("Separator", "The string separating the phrase name from the translation.");
			Draw("NewLine", "The string denoting a new line within a translation.");
			Draw("Comment", "The (optional) string separating the translation from the comment (empty = no comments).");
			Draw("Cache", "This allows you to control when the CSV file is loaded or unloaded.\nLoadImmediately = Translations will be loaded immediately, and kept in memory.\nLazyLoad = Translations will only when the current Language or SecondaryLanguage matches the CSV, and kept in memory.\nLazyLoadAndUnload = LazyLoad, but translations will be unloaded when the current Language or SecondaryLanguage differs from the CSV.\nLazyLoadAndUnloadPrimaryOnly = LazyLoadAndUnload, but only the CurrentLanguage will be used, the DefaultLanguage will be ignored.");

			EditorGUILayout.Separator();

			EditorGUI.BeginDisabledGroup(true);
				EditorGUILayout.LabelField("CollectItem" + Target.Separator + "アイテム" + Target.NewLine + "集めました" + Target.Comment + "Comment here");
			EditorGUI.EndDisabledGroup();

			EditorGUILayout.Separator();

			EditorGUILayout.BeginHorizontal();
				if (Any(t => t.Entries.Count > 0))
				{
					if (GUILayout.Button("Clear") == true)
					{
						Each(t => t.Clear());
					}
				}
				if (GUILayout.Button("Load Now") == true)
				{
					Each(t => t.LoadFromSource());
				}
				if (GUILayout.Button("Export") == true)
				{
					Each(t => t.ExportTextAsset());
				}
			EditorGUILayout.EndHorizontal();

			if (Targets.Length == 1)
			{
				var entries = Target.Entries;

				if (entries.Count > 0)
				{
					EditorGUILayout.Separator();

					EditorGUI.BeginDisabledGroup(true);
						foreach (var entry in entries)
						{
							EditorGUILayout.TextField(entry.Name, entry.Text);
						}
					EditorGUI.EndDisabledGroup();
				}
			}
		}
	}
}
#endif

namespace Lean.Localization
{
	/// <summary>This component will load localizations from a CSV file. By default they should be in the format:
	/// Phrase Name Here = Translation Here // Optional Comment Here</summary>
	[ExecuteInEditMode]
	[HelpURL(LeanLocalization.HelpUrlPrefix + "LeanLanguageCSV")]
	[AddComponentMenu(LeanLocalization.ComponentPathPrefix + "Language CSV")]
	public class LeanLanguageCSV : LeanSource
	{
		[System.Serializable]
		public class Entry
		{
			public string Name;
			public string Text;
		}

		public enum CacheType
		{
			LoadImmediately,
			LazyLoad,
			LazyLoadAndUnload,
			LazyLoadAndUnloadPrimaryOnly
		}

		/// <summary>The text asset that contains all the translations.</summary>
		public TextAsset Source;

		/// <summary>The language of the translations in the source file.</summary>
		[LeanLanguageName]
		public string Language;

		/// <summary>The string separating the phrase name from the translation.</summary>
		public string Separator = " = ";

		/// <summary>The string denoting a new line within a translation.</summary>
		public string NewLine = "\\n";

		/// <summary>The (optional) string separating the translation from the comment (empty = no comments).</summary>
		public string Comment = " // ";

		/// <summary>This allows you to control when the CSV file is loaded or unloaded.
		/// LoadImmediately = Translations will be loaded immediately, and kept in memory.
		/// LazyLoad = Translations will only when the current Language or SecondaryLanguage matches the CSV, and kept in memory.
		/// LazyLoadAndUnload = LazyLoad, but translations will be unloaded when the CurrentLanguage or DefaultLanguage differs from the CSV.
		/// LazyLoadAndUnloadPrimaryOnly = LazyLoadAndUnload, but only the CurrentLanguage will be used, the DefaultLanguage will be ignored.</summary>
		public CacheType Cache;

		/// <summary>This stores all currently loaded translations from this CSV file.</summary>
		public List<Entry> Entries { get { if (entries == null) entries = new List<Entry>(); return entries; } } [SerializeField] private List<Entry> entries;

		/// <summary>The characters used to separate each translation.</summary>
		private static readonly char[] newlineCharacters = new char[] { '\r', '\n' };

		private static Stack<Entry> entryPool = new Stack<Entry>();

		public override void Compile(string primaryLanguage, string secondaryLanguage)
		{
			// Lazy load only?
			switch (Cache)
			{
				case CacheType.LazyLoad:
				{
					if (Language != primaryLanguage && Language != secondaryLanguage)
					{
						return;
					}
				}
				break;

				case CacheType.LazyLoadAndUnload:
				{
					if (Language != primaryLanguage && Language != secondaryLanguage)
					{
						Clear();

						return;
					}
				}
				break;

				case CacheType.LazyLoadAndUnloadPrimaryOnly:
				{
					if (Language != primaryLanguage)
					{
						Clear();

						return;
					}
				}
				break;
			}

			if (entries == null || entries.Count == 0)
			{
				if (Application.isPlaying == true)
				{
					LoadFromSource();
				}
			}

			if (entries != null)
			{
				for (var i = entries.Count - 1; i >= 0; i--)
				{
					var entry       = entries[i];
					var translation = LeanLocalization.RegisterTranslation(entry.Name);

					translation.Register(Language, this);

					if (Language == primaryLanguage)
					{
						translation.Data    = entry.Text;
						translation.Primary = true;
					}
					else if (Language == secondaryLanguage && translation.Primary == false)
					{
						translation.Data = entry.Text;
					}
				}
			}
		}

		/// <summary>This will unload all translations from this component.</summary>
		[ContextMenu("Clear")]
		public void Clear()
		{
			if (entries != null)
			{
				entries.Clear();

				// Update translations?
				if (LeanLocalization.CurrentLanguage == Language)
				{
					LeanLocalization.UpdateTranslations();
				}
			}
		}

		/// <summary>This will load all translations from the CSV file into this component.</summary>
		[ContextMenu("Load From Source")]
		public void LoadFromSource()
		{
			if (Source != null && string.IsNullOrEmpty(Language) == false)
			{
				for (var i = Entries.Count - 1; i >= 0; i--) // NOTE: Property
				{
					entryPool.Push(entries[i]);
				}

				entries.Clear();

				// Split file into lines, and loop through them all
				var lines = Source.text.Split(newlineCharacters, System.StringSplitOptions.RemoveEmptyEntries);

				for (var i = 0; i < lines.Length; i++)
				{
					var line        = lines[i];
					var equalsIndex = line.IndexOf(Separator);

					// Only consider lines with the Separator character
					if (equalsIndex != -1)
					{
						var name = line.Substring(0, equalsIndex).Trim();
						var text = line.Substring(equalsIndex + Separator.Length).Trim();

						// Does this entry have a comment?
						if (string.IsNullOrEmpty(Comment) == false)
						{
							var commentIndex = text.LastIndexOf(Comment);

							if (commentIndex != -1)
							{
								text = text.Substring(0, commentIndex).Trim();
							}
						}

						// Replace newline markers with actual newlines
						if (string.IsNullOrEmpty(NewLine) == false)
						{
							text = text.Replace(NewLine, System.Environment.NewLine);
						}

						var entry = entryPool.Count > 0 ? entryPool.Pop() : new Entry();

						entry.Name = name;
						entry.Text = text;

						entries.Add(entry);
					}
				}

				// Update translations?
				if (LeanLocalization.CurrentLanguage == Language)
				{
					LeanLocalization.UpdateTranslations();
				}
			}
		}

#if UNITY_EDITOR
		/// <summary>This exports all text phrases in the LeanLocalization component for the Language specified by this component.</summary>
		[ContextMenu("Export Text Asset")]
		public void ExportTextAsset()
		{
			if (string.IsNullOrEmpty(Language) == false)
			{
				// Find where we want to save the file
				var path = EditorUtility.SaveFilePanelInProject("Export Text Asset for " + Language, Language, "txt", "");

				// Make sure we didn't cancel the panel
				if (string.IsNullOrEmpty(path) == false)
				{
					if (LeanLocalization.CurrentLanguage == Language)
					{
						DoExportTextAsset(path);
					}
					else
					{
						var oldLanguage = LeanLocalization.CurrentLanguage;

						LeanLocalization.CurrentLanguage = Language;

						DoExportTextAsset(path);

						LeanLocalization.CurrentLanguage = oldLanguage;
					}
				}
			}
		}

		private void DoExportTextAsset(string path)
		{
			var data = "";
			var gaps = false;

			// Add all phrase names and existing translations to lines
			foreach (var pair in LeanLocalization.CurrentTranslations)
			{
				var translation = pair.Value;

				if (gaps == true)
				{
					data += System.Environment.NewLine;
				}

				data += pair.Key + Separator;
				gaps  = true;

				if (translation.Data is string)
				{
					var text = (string)translation.Data;

					// Replace all new line permutations with the new line token
					text = text.Replace("\r\n", NewLine);
					text = text.Replace("\n\r", NewLine);
					text = text.Replace("\n", NewLine);
					text = text.Replace("\r", NewLine);

					data += text;
				}
			}

			// Write text to file
			using (var file = System.IO.File.OpenWrite(path))
			{
				var encoding = new System.Text.UTF8Encoding();
				var bytes    = encoding.GetBytes(data);

				file.Write(bytes, 0, bytes.Length);
			}

			// Import asset into project
			AssetDatabase.ImportAsset(path);

			// Replace Soure with new Text Asset?
			var textAsset = (TextAsset)AssetDatabase.LoadAssetAtPath(path, typeof(TextAsset));

			if (textAsset != null)
			{
				Source = textAsset;

				EditorGUIUtility.PingObject(textAsset);

				EditorUtility.SetDirty(this);
			}
		}
#endif
	}
}