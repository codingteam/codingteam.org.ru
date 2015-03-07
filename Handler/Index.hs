module Handler.Index (getIndexR) where

import Import
import Yesod.Form.Bootstrap3 (BootstrapFormLayout (..), renderBootstrap3,
                              withSmallInput)

import External.LogAccess

getIndexR :: Handler Html
getIndexR = do
    logPageSrc <- liftIO $ getTodayLogUrl
    defaultLayout $ do
        setTitle "codingteam"
        $(widgetFile "index/index")
