let data = {};
let pageNum = 1;
let hasNext = true;
function PostObj (id, title, description, publicated, publicateDate ){
    this.id = id;
    this.title = title;
    this.description = description;
    this.publicated = publicated;
    this.publicateDate = publicateDate;
}

function name(pageNumber, totalPages, hasPreviousPage, hasNextPage) {
    this.pageNumber = pageNumber;
    this.totalPages = totalPages;
    this.hasPreviousPage = hasPreviousPage;
    this.hasNextPage = hasNextPage;
}
const Bindings = {
    data() {
        data.Posts = data.Posts || [];
        return data;
    },
    methods: {
        readPost(id) {
            window.location.href = pageUtils.resolvePath("/Single?id=" + id);
        },
        getPosts() {
            var self = this;;
            if (hasNext) {
                $.post(pageUtils.resolvePath("Home/GetPosts"), { page: pageNum })
                    .done((data) => {
                        let answer = JSON.parse(JSON.stringify(data));
                        console.log(answer.page);
                        answer.posts.forEach((el, i, arr) => {
                            self.Posts.push($.extend(new PostObj(), el));
                        });
                        var hasNextPage = answer.page.hasNextPage;
                        hasNext = hasNextPage;
                        if (hasNextPage) {
                            pageNum += 1;
                            console.log(pageNum);
                        }
                    });
                console.log(data.Posts);
            }
        }
    },
    watch: {

    }
}
Vue.createApp(Bindings).mount('#app');