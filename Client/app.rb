require 'sinatra'
require 'date'
require 'httparty'
require 'json'
require 'byebug'

get '/' do
  csi_response = HTTParty.get("https://fortelliscsi.azurewebsites.net/api/associatecsi")
  # ["userId", "companyId", "payrollId", "firstName", "lastName", "scores"]
  @advisors = JSON.parse(csi_response.body)
  
  # dealership_response = HTTParty.get("test.com/api/DealershipCsi")

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
