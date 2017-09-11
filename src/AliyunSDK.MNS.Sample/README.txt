# Aliyun MNS Sample

This is a sample that demonstrates how to interactive with Aliyun MNS using the csharp SDK.

## Prerequisites

* You must have a valid Aliyun developer account, see [http://www.aliyun.com](http://www.aliyun.com).
* You must be signed up to use Aliyun MNS, see [http://www.aliyun.com/product/mns](http://www.aliyun.com/product/mns).

## Running the Sample

The basic steps are:

1. Fill the settings in SyncOperationSample/AsyncOperationSample with your Access Key ID, Secret Access Key, Account Id and Account Endpoint (Example: http://$AccountId.mns.cn-hangzhou.aliyuncs.com) :
> private const string _accessKeyId = "<your access key id>";
> private const string _secretAccessKey = "<your secret access key>";
> private const string _endpoint = "<valid endpoint>";
2. Set SyncOperationSample/AsyncOperationSample as StartTarget in project AliyunSDK_MNS_Sample.
3. Run the project AliyunSDK_MNS_Sample.
