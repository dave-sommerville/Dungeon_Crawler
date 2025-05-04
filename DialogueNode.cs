namespace Dungeon_Crawler
{
    public class DialogueNode
    {
        public string? InitialStatement { get; set; }
        public string[] PlayerOptions { get; set; }
        public string[][] NpcReplies { get; set; }
        public DialogueNode? FurtherDialogue { get; set; }
        public DialogueNode(string[] playerOptions, string[][]npcReplies, DialogueNode furtherDialogue)
        {
            PlayerOptions = playerOptions;
            NpcReplies = npcReplies;
            FurtherDialogue = furtherDialogue;
        }
        public void Node(NPC npc)
        {
            if (InitialStatement != null) { Utility.Print(InitialStatement); }
            for (int i = 0; i < PlayerOptions.Length; i++)
            {
                Utility.Print($"{i + 1}) {PlayerOptions[i]}");
            }
            int choice = Utility.PrintMenu(PlayerOptions.Length);
            Utility.Print(NpcReplies[choice - 1][Utility.GetRandomIndex(0, NpcReplies[choice - 1].Length)]);
            if (FurtherDialogue != null)
            {
                FurtherDialogue.Node(npc);
            } else
            {
                npc.InteractionInProgress = false;
            }
        }
    }
}
