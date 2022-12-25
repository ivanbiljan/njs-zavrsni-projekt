const HtmlWebpackPlugin = require("html-webpack-plugin");
const path = require("path");

module.exports = {
    // 'babel-polyfill',
    entry: ["./src/index.tsx"], // babel-polyfill for async await, entry point for building internal dependency graph
    output: {
        // where webpack emits the bundles and its name
        filename: "[name].[chunkhash].js",
        path: path.resolve(__dirname, "dist"),
        publicPath: "/",
        chunkFilename: "[id].[chunkhash].js",
    },
    devServer: {
        historyApiFallback: true,
    },
    devtool: "source-map", // So we can debug react in chrome rather than vanilla JS
    target: "web", // Instructs webpack to target a specific environment (web default)
    resolve: {
        // Configure how modules are resolved
        modules: [__dirname, "src", "node_modules"], // Tell webpack what directories should be searched when resolving modules
        extensions: ["*", ".js", ".jsx", ".tsx", ".ts"], // Attempt to resolve these extensions in order
    },
    optimization: {
        moduleIds: "deterministic",
        runtimeChunk: "single",
        splitChunks: {
            cacheGroups: {
                vendor: {
                    test: /[\\/]node_modules[\\/](react|react-dom|react-lottie-player|luxon|i18next|lottie-web)[\\/]/,
                    name: "vendors",
                    chunks: "all",
                },
            },
        },
    },
};