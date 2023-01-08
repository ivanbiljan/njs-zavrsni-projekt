const autoprefixer = require('autoprefixer');
const HtmlWebpackPlugin = require("html-webpack-plugin");
const common = require("./webpack.common.js");
const ReactRefreshWebpackPlugin = require("@pmmmwh/react-refresh-webpack-plugin");
const ForkTsCheckerWebpackPlugin = require("fork-ts-checker-webpack-plugin");
const webpack = require("webpack");
const { merge } = require("webpack-merge");
const CompressionPlugin = require("compression-webpack-plugin");

module.exports = merge(common, {
    mode: "development", // mode for build-in optimizations to correnspond for each environment
    plugins: [
        // perform wide range of tasks like bundle optimization, asset management and injection of environment variables.
        new HtmlWebpackPlugin({
            // generates an HTML and automatically injects all your generated bundles
            template: "./src/index.html",
        }),
        new webpack.DefinePlugin({
            process: {
                env: {
                    BE_ENV: JSON.stringify(process.env.BE_ENV || "localhost"),
                    BE_PORT: JSON.stringify(process.env.BE_PORT || 7175),
                },
            },
        }),
        new ForkTsCheckerWebpackPlugin(),
        new webpack.HotModuleReplacementPlugin(), // DEV ONLY!!! HMR exchanges, adds, or removes modules while an application is running, without a full reload
        new ReactRefreshWebpackPlugin(), // DEV ONLY!!! "Fast Refresh" for React shared.
        new CompressionPlugin(),
    ],
    devServer: {
        hot: true, // HMR
        historyApiFallback: true,
    },
    module: {
        // determine how the different types of modules within a project will be treated
        rules: [
            {
                test: /\.ts$|tsx/, // Include all modules that pass test assertion
                exclude: /node_modules/, // Exclude all modules matching any of these conditions
                loader: require.resolve("babel-loader"), // which loader to use
                options: {
                    plugins: [require.resolve("react-refresh/babel")].filter(Boolean),
                },
            },
            {
                test: /\.css$/,
                use: ["style-loader", "css-loader", "postcss-loader"],
            },
            {
                test: /\.png|jpg|gif$/,
                use: ["file-loader"],
            },
            {
                test: /\.svg$/,
                use: ["@svgr/webpack"],
            },
            {
                test: /\.s[ac]ss$/i,
                use: [
                    // Creates `style` nodes from JS strings
                    "style-loader",
                    // Translates CSS into CommonJS
                    "css-loader",
                    // Compiles Sass to CSS
                    "sass-loader"
                ],
            },
        ],
    },
});