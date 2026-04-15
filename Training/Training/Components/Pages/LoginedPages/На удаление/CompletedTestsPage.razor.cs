using Microsoft.EntityFrameworkCore;

namespace Training.Components.Pages.LoginedPages;

public class CompletedTestsPageModel: BaseModel
{
    protected IEnumerable<CompletedTest>? CompletedTests { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        //var rezult = await DbRepository.GetAllMyCompletedTest(MyUser);  //await DbRepository.GetEntitiesAsync<CompletedTest>(include: x=>x.Include(tc=>tc.TrainingCourse));
        //CompletedTests = rezult.data;
    }
}
