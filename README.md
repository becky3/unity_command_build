# unity_command_build
Unityをコマンドラインからビルドする

## iOSビルド

### 追加で必要な手順

- `xcodeBuild.sh`の以下部分にUUIDを設定<br>`PROVISIONING_PROFILE="XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"`
- `ExportOptions.plist` をプロジェクトフォルダ直下に配置
- プロビジョニングプロファイルに合わせ、Unityのbuild identifierを設定

### コマンド 
```Shell
sh unityiOSBuild.sh
```
### 関連記事
- UnityのiOSビルドをコマンドラインから行う (Mac用)<br>https://qiita.com/beckyJPN/items/ae73dd664b17f56be5ef

## Androidビルド

### コマンド 
```Shell
sh unityAndroidBuild.sh
```

### 関連記事
- UnityのAndroidビルドをコマンドラインから行う (Mac用)<br>https://qiita.com/beckyJPN/items/e61834c4b92112bc872d
