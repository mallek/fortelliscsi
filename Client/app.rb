require 'sinatra'
require 'date'
require 'httparty'
require 'json'
require 'byebug'

get '/' do
  @advisors = {
    travis: [
      {:month_of=>"2019-03-01", :csi_score=>56},
      {:month_of=>"2019-02-01", :csi_score=>0},
      {:month_of=>"2019-01-01", :csi_score=>16},
      {:month_of=>"2018-12-01", :csi_score=>90},
      {:month_of=>"2018-11-01", :csi_score=>82},
      {:month_of=>"2018-10-01", :csi_score=>10},
      {:month_of=>"2018-09-01", :csi_score=>72},
      {:month_of=>"2018-08-01", :csi_score=>40},
      {:month_of=>"2018-07-01", :csi_score=>10},
      {:month_of=>"2018-06-01", :csi_score=>85},
      {:month_of=>"2018-05-01", :csi_score=>60},
      {:month_of=>"2018-04-01", :csi_score=>29},
      {:month_of=>"2018-03-01", :csi_score=>70},
      {:month_of=>"2018-02-01", :csi_score=>70},
      {:month_of=>"2018-01-01", :csi_score=>36},
      {:month_of=>"2017-12-01", :csi_score=>90},
      {:month_of=>"2017-11-01", :csi_score=>58},
      {:month_of=>"2017-10-01", :csi_score=>32},
      {:month_of=>"2017-09-01", :csi_score=>80},
      {:month_of=>"2017-08-01", :csi_score=>47},
      {:month_of=>"2017-07-01", :csi_score=>16},
      {:month_of=>"2017-06-01", :csi_score=>44},
      {:month_of=>"2017-05-01", :csi_score=>44},
      {:month_of=>"2017-04-01", :csi_score=>75}
    ],
    max: [
      {:month_of=>"2019-04-01", :csi_score=>17},
      {:month_of=>"2019-03-01", :csi_score=>30},
      {:month_of=>"2019-02-01", :csi_score=>80},
      {:month_of=>"2019-01-01", :csi_score=>92},
      {:month_of=>"2018-12-01", :csi_score=>90},
      {:month_of=>"2018-11-01", :csi_score=>12},
      {:month_of=>"2018-10-01", :csi_score=>73},
      {:month_of=>"2018-09-01", :csi_score=>52},
      {:month_of=>"2018-08-01", :csi_score=>22},
      {:month_of=>"2018-07-01", :csi_score=>20},
      {:month_of=>"2018-06-01", :csi_score=>9},
      {:month_of=>"2018-05-01", :csi_score=>48},
      {:month_of=>"2018-04-01", :csi_score=>1},
      {:month_of=>"2018-03-01", :csi_score=>94},
      {:month_of=>"2018-02-01", :csi_score=>70},
      {:month_of=>"2018-01-01", :csi_score=>60},
      {:month_of=>"2017-12-01", :csi_score=>67},
      {:month_of=>"2017-11-01", :csi_score=>30},
      {:month_of=>"2017-10-01", :csi_score=>36},
      {:month_of=>"2017-09-01", :csi_score=>80},
      {:month_of=>"2017-08-01", :csi_score=>73},
      {:month_of=>"2017-07-01", :csi_score=>56},
      {:month_of=>"2017-06-01", :csi_score=>99},
      {:month_of=>"2017-05-01", :csi_score=>12},
      {:month_of=>"2017-04-01", :csi_score=>75}
    ]
  }

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
