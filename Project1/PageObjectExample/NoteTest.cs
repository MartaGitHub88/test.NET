using Xunit;

namespace PageObjectExample
{
    public class NoteTest : BaseTest
    {
        [Fact]
        public void Can_publish_new_note()
        {
            var loginPage = LoginPage.Open(GetBrowser());
            var adminPanel = loginPage.Login("automatyzacja", "auto@Zima2019");
            var exampleNote = new ExampleNote();
            var CreateNewNote = adminPanel.CreateNewNote(exampleNote);
            //var exampleComment = new ExampleComment();
            //var NewestNoteExists = note.AddNote(exampleComment);



            //zalogować się do panelu admina
            //utworzyc notatkę
            //wylogowac
            //nowa notatka jest opublikowana


        }

    }
}


  
