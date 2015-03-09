module Handler.Home (getIndexR, getResourcesR) where

import Import
import External.LogAccess

getIndexR :: Handler Html
getIndexR = do
    logPageSrc <- liftIO $ getTodayLogUrl
    defaultLayout $ do
        setTitle "codingteam"
        $(widgetFile "index/index")

getResourcesR :: Handler Html
getResourcesR = do
    defaultLayout $ do
        setTitle "codingteam / Resources"
        $(widgetFile "resources/resources")
