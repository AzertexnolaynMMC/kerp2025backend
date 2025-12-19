namespace kerp.SystemModel
{
    public class CustomerResponseModel<T>
    {

        public int StatusCode { get; set; }
        public string? title { get; set; }
        public string? AccessToken { get; set; }
        public T? Data { get; set; }
    }
}

/*
   final int statusCode;
  final String title;
  final T? model;
  final String? accessToken; 
*/