# 语音朗读器使用说明：

修改app.config中的inputFileName, 修改为需要读取的yml文件即可
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <!--<add key="voiceEngineName" value="IVONA 2 Joey" />-->
    <add key="voiceEngineName" value="IVONA 2 Kendra" />
    <!--<add key="voiceEngineName" value="IVONA 2 Eric" />-->
    <add key="sampleText" value="This example demonstrates a basic use of Speech Synthesizer, can you read a long sentences?" />
    <add key="outputWaveFileName" value="C:\\Test\\Sample8.wav" />
    <!--将需要读的文件放在下面，使用yml格式的好处就是其格式非常规整，处理起来方便至极-->
    <!--<add key="inputFileName" value="biAnimal.yml" />-->
    <add key="inputFileName" value="D:\rubyOnRails\trans42\script\courses\biAnimal.yml" />
  </appSettings>
</configuration>
```
yml文件格式这样写：
```yaml
  running:
  - a man is running
  - she is running
  - baby elephant is running
  - two girls are running
  - dogs are running
  - a boy is running on water
  - people are running after a dog
```