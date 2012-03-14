describe 'POST index' do
  include Rack::Test::Methods

  let(:app) {Sinatra::Application}

  it 'parses the post data found in the payload' do
    post_data = IO.read('post_data.txt')
    p post_data
    post '/', :payload => post_data
  end
end
