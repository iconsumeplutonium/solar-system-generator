using System.Collections.Generic;

public static class WordInventor {

    public static string InventCelestialName(int seed) {
        System.Random wrng = new System.Random(seed);
        int wordLength = wrng.Next(3, 8);
        List<int> wordInIndexes = CreateWord(wordLength, wrng);

        return ConvertIndexWordToString(wordInIndexes);
    }



    public static List<int> CreateWord(int wordLength, System.Random wrng) {
        WordDictionary w = new WordDictionary();
        List<int> wordInIndexes = new List<int>();

        int index;
        for (int i = 0; i < wordLength; i++) {
            if (i == 0) {
                index = wrng.Next(0, WordList.words.Length - 1);
                w = WordList.words[index];
            }

            wordInIndexes.Add(w.index);
            index = wrng.Next(0, w.followingSounds.Count - 1);
            w = WordList.words[w.followingSounds[index]];

        }

        return wordInIndexes;
    }

    public static string ConvertIndexWordToString(List<int> word) {
        string w = "";
        for (int i = 0; i < word.Count; i++) {
            if (i == 0) {
                char[] sound = WordList.words[word[i]].sound.ToCharArray();
                w += (sound.Length == 2) ? sound[0].ToString().ToUpper() + sound[1].ToString() : sound[0].ToString().ToUpper();

            }
            else
                w += WordList.words[word[i]].sound;
        }
        return w;
    }

}
