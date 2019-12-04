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
            var newNoteUrl = adminPanel.CreateNewNote(exampleNote);
            adminPanel.LogOut();
            var notePage = new NotePage(GetBrowser());
            notePage.GoTo(newNoteUrl);
            Assert.True(notePage.HasNote(exampleNote));
            
        }

    }
}


  
