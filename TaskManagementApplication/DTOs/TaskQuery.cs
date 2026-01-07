namespace TaskManagementApplication.DTOs
{
    public record TaskQuery(
        string? Status,
        string? Priority,
        int Page = 1,
        int PageSize = 10,
        string SortBy = "DueDate",
        string SortDir = "ASC"
    );
}
