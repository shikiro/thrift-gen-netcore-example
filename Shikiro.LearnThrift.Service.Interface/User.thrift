namespace csharp Shikiro.LearnThrift.Service.Interface.User

service IUserService{
	list<User> GetAll()
}

struct User
{
	1:i32 Id
	2:string Name
}