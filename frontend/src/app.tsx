import { Route, Routes } from "react-router-dom";
import { Home, Route as HomeRoute } from "./home/Home";
import { YayModalContainer } from "./shared/yay-modal/YayModalContainer";
import { Login, LoginRoute, Register, RegisterRoute } from "./authentication";
import { QueryClient, QueryClientProvider } from "react-query";

const queryClient = new QueryClient({
    defaultOptions: {
        queries: {
            staleTime: 30000,
            refetchOnWindowFocus: false,
        },
    },
});

const App = () => {
    return (
        <QueryClientProvider client={queryClient}>
            <div className={"app"}>
                <YayModalContainer />
                <Routes>
                    <Route path={RegisterRoute} element={<Register />} />
                    <Route path={LoginRoute} element={<Login />} />
                    <Route path={HomeRoute} element={<Home />} />
                </Routes>
            </div>
        </QueryClientProvider>
    );
};

export default App;