module External.LogAccessSpec (spec) where

import Prelude
import Data.Text

import External.LogAccess
import TestImport

spec :: Spec
spec = withApp $ do
    describe "getLogUrl" $ do
        it "returns proper log url" $ do
            assertEqual "log urls should be equal" (getLogUrl (2015, 1, 1)) "http://0xd34df00d.me/logs/chat/codingteam@conference.jabber.ru/2015/01/01.html"
