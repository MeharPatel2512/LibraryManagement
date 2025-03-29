namespace Library.Utility.DBConstants{
    class   StoredProcedureConstants{
        public static readonly string REGISTER_USER = $"{SchemaConstants.Schema_Users}.Register_User"; 
        public static readonly string LOGIN_USER = $"{SchemaConstants.Schema_Users}.Login_User"; 
        public static readonly string GET_PROFILE = $"{SchemaConstants.Schema_Users}.Get_Profile"; 
        public static readonly string UPDATE_USER_DATA = $"{SchemaConstants.Schema_Users}.Update_User_Data"; 
        public static readonly string GET_HASHPASSWORD = $"{SchemaConstants.Schema_Users}.Get_PasswordHash"; 
        public static readonly string DELETE_USER = $"{SchemaConstants.Schema_Users}.Delete_User"; 
        public static readonly string CHANGE_PASSWORD = $"{SchemaConstants.Schema_Users}.Change_Password"; 
        public static readonly string GET_SUBSCRIPTION = $"{SchemaConstants.Schema_Users}.Get_Subscription"; 
        public static readonly string GET_SUBSCRIPTION_TYPES = $"{SchemaConstants.Schema_Subscription}.Get_Subscription_Types"; 
        public static readonly string GET_ALL_USERS = $"{SchemaConstants.Schema_Admin}.Get_All_Users"; 
        public static readonly string UPSERT_BOOK = $"{SchemaConstants.Schema_Book}.Upsert_Book"; 
        public static readonly string DELETE_BOOK = $"{SchemaConstants.Schema_Book}.Delete_Book"; 
        public static readonly string GET_BOOKS = $"{SchemaConstants.Schema_Book}.Get_Book"; 
        public static readonly string BORROW_A_BOOK = $"{SchemaConstants.Schema_BorrowBook}.Borrow_a_Book";
        public static readonly string GET_BORROWED_BOOKS = $"{SchemaConstants.Schema_BorrowBook}.Get_Borrowed_Books";
        public static readonly string RETURN_BOOK = $"{SchemaConstants.Schema_BorrowBook}.Return_Book";
    }
}