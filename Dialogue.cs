namespace Dungeon_Crawler
{
    public class Dialogue
    {
        public string Intro { get; set; }
        public string Greeting { get; set; }
        public DialogueNode DialogueNode { get; set; }

        public void InteractWithNpc(Player player, NPC npc)
        {
            npc.InteractionInProgress = true;
            do
            {
                if (Intro != null) { Utility.Print(Intro); }
                if (Greeting != null) { Utility.Print(Greeting); }
                if (npc.Description != null) { Utility.Print(npc.Description); }
                DialogueNode.Node(npc);
            } while (npc.InteractionInProgress);
        }
    }
}
