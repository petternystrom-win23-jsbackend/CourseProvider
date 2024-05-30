using CourseProvider.Infrastructure.Data.Contexts;
using CourseProvider.Infrastructure.Factories;
using CourseProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProvider.Infrastructure.Services;

public interface ICourseService
{
    Task<Course> CreateCourseAsync(CourseCreateRequest request);
    Task<Course> UpdateCourseAsync(CourseUpdateRequest request);

    Task<Course> GetCourseByIdAsync(string id);
    Task<IEnumerable<Course>> GetAllCoursesAsync();

    Task<bool> DeleteCourseAsync(string id);
}
public class CourseService(IDbContextFactory<DataContext> contextFactory) : ICourseService
{
    private readonly IDbContextFactory<DataContext> _contextFactory = contextFactory;

    public async Task<Course> CreateCourseAsync(CourseCreateRequest request)
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntity = CourseFactory.Create(request);
        context.Courses.Add(courseEntity);

        await context.SaveChangesAsync();

        return CourseFactory.Create(courseEntity);

    }
    public async Task<Course> UpdateCourseAsync(CourseUpdateRequest request)
    {
        await using var context = _contextFactory.CreateDbContext();
        var existingCourse = await context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id);
        if (existingCourse == null)
        {
            return null!;
        }
        var updatedCourseEntity = CourseFactory.Update(request);
        updatedCourseEntity.Id = existingCourse.Id;
        context.Entry(existingCourse).CurrentValues.SetValues(updatedCourseEntity);

        await context.SaveChangesAsync();
        return CourseFactory.Create(existingCourse);
    }
    public async Task<Course> GetCourseByIdAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntity = await context.Courses.FirstOrDefaultAsync(course => course.Id == id);
        return courseEntity == null ? null! : CourseFactory.Create(courseEntity);
    }
    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntities = await context.Courses.ToListAsync();
        return courseEntities.Select(CourseFactory.Create);
    }
    public async Task<bool> DeleteCourseAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntity = await context.Courses.FirstOrDefaultAsync(course => course.Id == id);
        if (courseEntity == null)
        {
            return false;
        }
        context.Courses.Remove(courseEntity);
        await context.SaveChangesAsync();
        return true;
    }

    
}
