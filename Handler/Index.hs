module Handler.Index (getIndexR) where

import Import
import Yesod.Form.Bootstrap3 (BootstrapFormLayout (..), renderBootstrap3,
                              withSmallInput)

--getLogPageSrc :: IO Text
--getLogPageSrc = do


getIndexR :: Handler Html
getIndexR = do
    defaultLayout $ do
        --logPageSrc <- getLogPageSrc
        setTitle "codingteam"

        $(widgetFile "index/index")
