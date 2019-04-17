require 'sinatra'
require 'date'
require 'httparty'
require 'json'
require 'byebug'

get '/' do
  # bypass Fortellis
  # csi_response = HTTParty.get("https://fortelliscsi.azurewebsites.net/csi/associatecsi")
  
  # Fortellis endpoint
  # csi_response = HTTParty.get("https://api.fortellis.io/csi/associatecsi")
  
  # ["userId", "companyId", "payrollId", "firstName", "lastName", "scores"]
  # @advisors = JSON.parse(csi_response.body)
  
  url = "https://identity.fortellis.io/oauth2/aus1p1ixy7YL8cMq02p7/v1/token"
  auth_response = HTTParty.post(
    url,
    body: {
      grant_type: "client_credentials",
      redirect_uri: "https://api.fortellis.io/csi/associatecsi",
      client_id: "El4o8Gm25FFKElAmzgAviHhJLUqa1ds6",
      client_secret: "rGizjQgsIJxVfgND",
      scope: "anonymous"
    }
  )

  auth = JSON.parse(auth_response.body)

  subscription_id = "test"
  subscription_id = "47719450-d01d-44b9-99af-34615ec74157"

  a_response = HTTParty.get(
    "https://api.fortellis.io/csi/AssociateCsi", 
    headers: {
      "Subscription-Id" => subscription_id,
      "Authorization" => "Bearer #{auth["access_token"]}",
    }
  )
  
  a_json_response = JSON.parse(a_response.body)
  pp a_json_response

  d_response = HTTParty.get(
    "https://api.fortellis.io/csi/DealershipCsi", 
    headers: {
      "Subscription-Id" => subscription_id,
      "Authorization" => "Bearer #{auth["access_token"]}",
    }
  )
  
  d_json_response = JSON.parse(d_response.body)
  pp d_json_response

  @advisors = a_json_response

  @formatted_series = []
  @series = @advisors.each do |advisor_hash|
    @formatted_series.push(
      {
        name: "#{advisor_hash["firstName"]} #{advisor_hash["lastName"]}",
        data: advisor_hash["scores"].map{|h| h["score"]}
      }
    )
  end
  erb :index
end
