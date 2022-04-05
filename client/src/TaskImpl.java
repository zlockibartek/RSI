public class TaskImpl implements Task {
    private static final long serialVersionUID = 1L;

    public Object compute(Object[] params) {
        ResultType res = new ResultType();
        if (Math.random() > 0.6) {
            res.result_description = "Something went wrong. Random value is greater than 0.6";
            res.result = null;
        } else {
            res.result_description = "Repeated string " + params[1] + " times";
            res.result = ((String) params[0]).repeat((int) params[1]);
        }
        return res;
    }
}