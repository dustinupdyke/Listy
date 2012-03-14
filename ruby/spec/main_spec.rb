describe 'POST index' do
  include Rack::Test::Methods

  let(:app) {Sinatra::Application}

  it 'parses the post data found in the payload' do
    post_data = '{"items":[],"user_id":"a8c0e7d3-8a83-a280-33cd-73bfd5be994e","list_id":"b977c0e0-31c0-96d3-c3b6-a842460bc44f"}'
    post '/lists/create', :payload => post_data
  end
end
