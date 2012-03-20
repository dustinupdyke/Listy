describe 'POST /lists/create' do
  include Rack::Test::Methods

  let(:app) {Sinatra::Application}

  post_data = '{"items":[],"user_id":"a8c0e7d3-8a83-a280-33cd-73bfd5be994e","list_id":"b977c0e0-31c0-96d3-c3b6-a842460bc44f"}'

  before(:each) do
    @mongo_connection = double("Mongo::Connection")
    Mongo::Connection.stub(:new).and_return(@mongo_connection)
    @mongo_db = double("Mongo::DB")
    @mongo_connection.stub(:[]).with(anything).and_return(@mongo_db)
    @mongo_collection = double("Mongo::Collection").as_null_object
    @mongo_db.stub(:[]).with(anything).and_return(@mongo_collection)
  end

  it "returns a successful response if there is no error" do
    post '/lists/create', post_data
    last_response.should be_ok
  end

  it "parses the post data found in the payload" do
    @mongo_collection.stub(:save) { |document| @payload = document }

    post '/lists/create', post_data
    last_response.should be_ok
    @payload["user_id"].should == "a8c0e7d3-8a83-a280-33cd-73bfd5be994e"
    @payload["list_id"].should == "b977c0e0-31c0-96d3-c3b6-a842460bc44f"
  end

  it "saves the list to the lists collection" do
    @mongo_db.should_receive(:[]).with("lists").and_return(@mongo_collection)
    @mongo_collection.should_receive(:save).with(anything())
    post '/lists/create', post_data
  end
end
