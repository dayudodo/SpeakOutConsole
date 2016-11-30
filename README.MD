# 语音朗读器使用说明：
主功能：朗读文本成为声音文件。
必备软件：
- TTS引擎，比如INOVA, neo speech等
- 使用了ffmpeg来进行声音文件的转换处理，请先安装[ffmpeg](http://ffmpeg.org)

## 无参数模式
```
speak
```
会自动读取配置中的inputFileName项，app.config配置文件如下：
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
biAnimal.yaml文件格式如下：
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
如此，朗读为a man is running.mp3及she is running...的声音文件

## 指定yaml模式
```
speak -yml abc.yml
```
会自动朗读abc.yml，第一个参数必须为-yml

## 读单词模式
```
speak.exe man woman "a real sentence"
```
即可在当前目录下生成这几个mp3文件，分别为man.mp3, woman.mp3，a real sentence.mp3
