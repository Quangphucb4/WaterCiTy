pushd Repository\WaterCity.Repository
dotnet ef migrations add DeMo_APIHUFI -v --context AppDbContext
dotnet ef database update -v --context AppDbContext
pause
popd